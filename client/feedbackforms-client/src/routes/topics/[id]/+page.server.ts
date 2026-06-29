import type { PageServerLoad } from "./$types";
import { createApiClient } from "$lib/api-client";
import type { Actions } from "./$types";
import { fail, redirect } from "@sveltejs/kit";

export const load: PageServerLoad = async ({ params, cookies }) => {
    const token = cookies.get("access_token");
    const apiClient = createApiClient(token);

    const topic = await apiClient.api.topicsDetail(params.id);

    if (topic.data.isOwner && topic.data.id)
    {
        const answers = await apiClient.api.answersByTopicDetail(topic.data.id);
        return {
            answers: answers.data,
            topic: topic.data
        }
    }

    return {
        topic: topic.data
    };
}

export const actions = {
    default: async ({params, request}) => {
        const data = await request.formData();
        const userName = data.get("username");
        const email = data.get("email");
        const text = data.get("text");
        const captchaToken = data.get('cf-turnstile-response');

        if (!userName) {
            return fail(400, { userName, missing: true});
        }

        if (!email) {
            return fail(400, { email, missing: true });
        }

        if (!text) {
            return fail(400, { text, missing: true });
        }

        if (!captchaToken) {
            return fail(400, { message: "Please confirm that you are not a robot" });
        }
        
        const apiClient = createApiClient();
        try {
            await apiClient.api.answersCreate({
                userName: userName.toString(),
                email: email.toString(),
                text: text.toString(),
                topicId: params.id,
                captchaToken: captchaToken.toString()
            });
        } catch (e: any) {
            return fail(400, {
                message: e.message ?? "Bad request"
            });
        }
        
        throw redirect(303, "/thankyou")
    }
} satisfies Actions;

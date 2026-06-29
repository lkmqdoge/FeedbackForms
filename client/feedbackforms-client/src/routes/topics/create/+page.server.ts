import { fail, redirect } from "@sveltejs/kit";
import type { Actions } from "./$types";
import { createApiClient } from "$lib/api-client";

export const actions = {
    default: async ({request, cookies}) => {
        const token = cookies.get("access_token");
        const userId = cookies.get("user_id");
        if (!token || !userId) {
            redirect(303, "/login");
        }

        const data = await request.formData();
        const title = data.get("title");
        const description = data.get("description");

        if (!title) {
            return fail(400, { title, missing: true });
        }

        if (!description) {
            return fail(400, { description, missing: true });
        }
        
        const apiClient = createApiClient("access_token");

        const topicId = (await apiClient.api.topicsCreate({
            userId: userId,
            title: title.toString(),
            body: description.toString(),
        })).data;

        if (topicId) {
            redirect(303, `/topics/${topicId}`);
        }
        
        return { success: false }
    }
} satisfies Actions;

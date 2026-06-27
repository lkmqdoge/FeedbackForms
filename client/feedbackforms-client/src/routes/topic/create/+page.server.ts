import { fail, redirect } from "@sveltejs/kit";
import type { Actions } from "../../hello/$types";
import { createTopic } from "$lib/api";

export const actions = {
    default: async ({request}) => {
        const data = await request.formData();
        const title = data.get("title");
        const description = data.get("description");

        if (!title) {
            return fail(400, { title, missing: true });
        }

        if (!description) {
            return fail(400, { description, missing: true });
        }

        const topicId = await createTopic({
            title: title.toString(),
            body: description.toString()
        });

        if (topicId) {
            redirect(303, `/topic/${topicId}`);
        }
        
        return { success: false }
    }
} satisfies Actions;

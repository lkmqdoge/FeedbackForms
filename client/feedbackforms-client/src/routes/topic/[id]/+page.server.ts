import { error } from "@sveltejs/kit"
import type { PageServerLoad } from "./$types";
import { getTopicById } from "$lib/api";

export const load: PageServerLoad = async ({ params }) => {
    const topic = await getTopicById({ id: params.id });

    if (!topic) {
        error(404, "not found");
    }

    return topic;
}

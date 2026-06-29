import { redirect } from "@sveltejs/kit";
import type { PageServerLoad } from "./$types";
import { createApiClient } from "$lib/api-client";

export const load: PageServerLoad = async ({ cookies }) => {
    const token = cookies.get("access_token");
    if (!token) {
        throw redirect(303, "/login");
    }
    
    const apiClient = createApiClient(token);
    const user = await apiClient.api.usersMeList();

    if (!user.data.id) {
        redirect(303, "/login");
    }

    const topics = await apiClient.api.topicsByUserDetail(user.data.id);

    return {
        user: user.data,
        topics: topics.data
    }
}

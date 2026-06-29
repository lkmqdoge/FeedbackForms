import { createApiClient } from "$lib/api-client";
import type { PageServerLoad } from "./$types";

export const load: PageServerLoad = async ({ params, locals }) => {
    const apiClient = createApiClient();
    const data = await apiClient.api.helloList();
    return {
        hello: data.data.toString(),
    }
}

import { createApiClient } from "$lib/api-client";
import type { LayoutServerLoad } from "./$types";

export const load: LayoutServerLoad = async ({ cookies }) => {
    const token = cookies.get("access_token");
	const userName = cookies.get("user_name");

	if (!token) {
		return { userName: undefined };
	}

	try {
		await createApiClient(token).api.usersMeList();
		return { userName };
	} catch {
		return { userName: undefined };
	}
}

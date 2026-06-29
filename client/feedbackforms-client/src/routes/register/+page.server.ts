import { fail, redirect } from "@sveltejs/kit";
import type { Actions } from "./$types";
import { createApiClient } from "$lib/api-client";

export const actions = {
    default: async ({request}) => {
        const data = await request.formData();
        const userName = data.get("username");
        const email = data.get("email");
        const password = data.get("password");

        if (!userName) {
            return fail(400, { userName, missing: true });
        }

        if (!email) {
            return fail(400, { email, missing: true });
        }

        if (!password) {
            return fail(400, { password, missing: true });
        }
        
        const apiClient = createApiClient();
        const userId = await apiClient.api.usersRegisterCreate({
            userName: userName.toString(),
            email: email.toString(),
            password: password.toString()
        });

        if (userId.data) {
            redirect(303, "/login");
        }
        
        return { success: false }
    }
} satisfies Actions;

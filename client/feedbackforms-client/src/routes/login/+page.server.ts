import { fail, redirect } from '@sveltejs/kit';
import type { Actions } from './$types';
import { createApiClient } from '$lib/api-client';

export const actions = {
    default: async ({ request, cookies }) => {
        const data = await request.formData();
        const email = data.get('email');
        const password = data.get('password');

        if (!email) {
            return fail(400, { email, missing: true });
        }

        if (!password) {
            return fail(400, { password, missing: true });
        }

        const apiClient = createApiClient();

        const token = await apiClient.api.usersLoginCreate({
            email: email.toString(),
            password: password.toString(),
        });


        if (!token) return fail(400, { message: 'Invalid credentials' });

        const apiClientWithToken = createApiClient(token.data);
        const user = await apiClientWithToken.api.usersMeList();

        if (!user.data.id || !user.data.userName) return fail(400, { message: 'Invalid credentials' });

        cookies.set("access_token", token.data, {
            path: '/',
            httpOnly: true,
            maxAge: 60 * 60 * 24
        });

        cookies.set("user_id", user.data.id, {
            path: '/',
            httpOnly: true,
            maxAge: 60 * 60 * 24
        });

        cookies.set("user_name", user.data.userName, {
            path: '/',
            httpOnly: true,
            maxAge: 60 * 60 * 24
        });

        throw redirect(303, '/dashboard');
    }
} satisfies Actions;

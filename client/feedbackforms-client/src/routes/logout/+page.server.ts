import { redirect } from "@sveltejs/kit";
import type { Actions } from "./$types";

export const actions = {
    default: async ({cookies}) => {
        cookies.delete("access_token", { path: "/" });
        cookies.delete("user_id", { path: "/" });
        cookies.delete("user_name", { path: "/"})
       
        throw redirect(303, '/login');
    }
} satisfies Actions;

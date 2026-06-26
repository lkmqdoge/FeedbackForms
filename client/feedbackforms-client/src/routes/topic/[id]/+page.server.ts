import { error } from "@sveltejs/kit"
import type { PageServerLoad } from "./$types";

export const load: PageServerLoad = ({ params }) => {
    if (params.id === "")
        return;

    error(404, "not found");
}

import type { PageServerLoad } from "./$types";

export const load: PageServerLoad = async ({ params, locals }) => {
    const response = await fetch("http://backend:8080");
    const data = await response.json();
    return data
}

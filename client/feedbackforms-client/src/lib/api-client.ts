import { Api } from "./api/Api";
import { config } from "./config";

export function createApiClient(token?: string) {
    const client = new Api({
        baseURL: config.apiBaseUrl,
        headers: { "Content-Type": "application/json" },
        timeout: 5000,
        withCredentials: true
    });

    client.instance.interceptors.response.use((config) => {
        console.log("FULL URL:", (config.config.baseURL ?? "") + config.config.url);
        return config
    })

    if (token) {
        client.instance.interceptors.request.use((config) => {
            config.headers.Authorization = `Bearer ${token}`;
            return config;
        });
    }

    return client;
}

import axios from "axios";
import { config } from "./config";

const apiClient = axios.create({
    baseURL: config.apiBaseUrl,
    headers: { "Content-Type": "application/json" }
})

export async function createTopic(request: { title: string, body: string }) {
    return (await apiClient.post<string>("topics/create", request)).data;

}

export async function getTopicById(request: { id: string }) {
    return (await apiClient.get<Topic>(`/topics/get/${request.id}`)).data;
}

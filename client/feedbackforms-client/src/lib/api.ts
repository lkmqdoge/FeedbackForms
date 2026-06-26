import axios from "axios";

const apiClient = axios.create({
    baseURL: "localhost:5432",
    headers: { "Content-Type": "application/json" }
})

// export async function createTopic()

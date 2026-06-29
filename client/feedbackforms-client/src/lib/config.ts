import * as dotenv from "dotenv";
dotenv.config();

export const config = {
    apiBaseUrl: process.env.API_BASE_URL ?? "http://localhost:5086"
}

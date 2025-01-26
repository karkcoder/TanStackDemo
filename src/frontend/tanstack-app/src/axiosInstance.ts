import axios from "axios";

const axiosInstance = axios.create({
  baseURL: "http://localhost:5215", // Replace with your actual API URL
  headers: {
    "Content-Type": "application/json",
    // Add any other necessary headers (e.g., Authorization)
    Authorization: "Bearer your-access-token",
  },
});

export { axiosInstance };

import axios from "axios";
import { BASE_URL } from "../config";

export const fetchAuth = async (credentials: {email:string; password:string}) => {
    const response = await axios.post(`${BASE_URL}/authentication/login`,credentials)
    return response.data;
};




import { InsuranceMembersApi } from "../api-client/apis/InsuranceMembersApi";

const api = new InsuranceMembersApi();

export const fetchInsuranceMembers = async () => {
  try {
    return await api.apiInsuranceMembersGet();
  } catch (error) {
    console.error("Error fetching insurance members:", error);
    throw error;
  }
};

import { useQuery } from "@tanstack/react-query";
import { useParams } from "@tanstack/react-router";
import { InsuranceMembersApi } from "../../api-client";

const api = new InsuranceMembersApi();

function InsuranceMemberDetails() {
  // Get the `id` from the route parameters
  const { memberId } = useParams({
    from: "/insurance-members/$memberId", // The route path with the parameter
  });

  // Fetch the insurance member data
  const { data, error, isLoading } = useQuery({
    queryKey: ["insurance-member", memberId], // Unique key for the query
    queryFn: () => api.apiInsuranceMembersIdGet({ id: Number(memberId) }), // Pass the `id` as a request parameter
  });

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>Error: {error.message}</div>;

  return (
    <div>
      <h1>
        {data?.firstName} {data?.lastName}
      </h1>
      <p>ID: {data?.id}</p>
      <p>Email: {data?.email}</p>
      {/* Render other fields of InsuranceMember */}
    </div>
  );
}

export default InsuranceMemberDetails;

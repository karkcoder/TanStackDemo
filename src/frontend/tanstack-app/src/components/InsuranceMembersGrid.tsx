import React, { useState, useEffect } from "react";
import { Grid, GridColumn } from "@progress/kendo-react-grid";
import { fetchInsuranceMembers } from "../service/fetchInsuranceMembers";
import { InsuranceMember } from "../api-client/models"; // Import the type

const InsuranceMembersGrid: React.FC = () => {
  const [data, setData] = useState<InsuranceMember[]>([]); // Explicitly specify the type
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadData = async () => {
      setLoading(true);
      try {
        const members = await fetchInsuranceMembers(); // Fetch the data
        setData(members); // Assign the data here
      } catch (error) {
        console.error("Error fetching insurance members:", error);
      } finally {
        setLoading(false);
      }
    };

    loadData();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div style={{ height: "500px" }}>
      <Grid
        data={data}
        take={10}
        skip={0}
        pageable={true}
        total={100} // Total number of records
      >
        <GridColumn field="id" hidden={true} title="ID" />
        <GridColumn field="firstName" title="First Name" />
        <GridColumn field="lastName" title="Last Name" />
        <GridColumn field="address1" title="Address 1" />
        <GridColumn field="address2" title="Address 2" />
        <GridColumn field="city" title="City" />
        <GridColumn field="state" title="State" />
        <GridColumn field="zip" title="Zip" />
        <GridColumn field="phoneNumber" title="Phone Number" />
        <GridColumn field="email" title="Email" />
        <GridColumn field="memberPlan" title="Member Plan" />
        <GridColumn
          field="dateOfBirth"
          title="Date of Birth"
          format="{0:MM/dd/yyyy}"
        />
        <GridColumn
          field="policyStartDate"
          title="Policy Start Date"
          format="{0:MM/dd/yyyy}"
        />
        <GridColumn
          field="policyEndDate"
          title="Policy End Date"
          format="{0:MM/dd/yyyy}"
        />
      </Grid>
    </div>
  );
};

export default InsuranceMembersGrid;

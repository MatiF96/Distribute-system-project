import React, { useState } from 'react';
import { Container, Wrapper, Title, StyledButton, CurrentButton } from './styled';
import EmployeesApi from "../../api/EmployeesApi";

const EditEmployee = ({ employee, refreshData }) => {

  const ChangeRole = (role) => {

    let data = {
      userId: employee.id,
      role: role
    };

    console.log(data)
    EmployeesApi.update(employee.id,data)
    .then((res) => {
      refreshData()
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleAdminClick = () => {
    ChangeRole("ADMIN")
    refreshData();
  };

  const handleCustomerClick = () => {
    ChangeRole("CUSTOMER")
    refreshData();
  };

  const handleEmployeeClick = () => {
    ChangeRole("EMPLOYEE")
    refreshData();
  };

    return (
      <Container>
        <Wrapper>
          <Title>{employee.username} :</Title>
          {employee.role==="ADMIN"?<CurrentButton>ADMIN</CurrentButton>:<StyledButton onClick={handleAdminClick}>ADMIN</StyledButton>}
          {employee.role==="CUSTOMER"?<CurrentButton>CUSTOMER</CurrentButton>:<StyledButton onClick={handleCustomerClick}>CUSTOMER</StyledButton>}
          {employee.role==="EMPLOYEE"?<CurrentButton>EMPLOYEE</CurrentButton>:<StyledButton onClick={handleEmployeeClick}>EMPLOYEE</StyledButton>}
        </Wrapper>
      </Container>
  )};
  
  export default EditEmployee;
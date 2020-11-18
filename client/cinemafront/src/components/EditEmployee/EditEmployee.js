import React from 'react';
import { Container, Wrapper, Title, StyledButton, CurrentButton } from './styled';
import EmployeesApi from "../../api/EmployeesApi";
import { ADMIN, EMPLOYEE, CUSTOMER} from "../../utils/Roles"

const EditEmployee = ({ employee, refreshData }) => {

  const ChangeRole = (role) => {

    let data = {
      userId: employee.id,
      role: role
    };

    EmployeesApi.update(employee.id,data)
    .then((res) => {
      refreshData()
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleClick = (role) => {
    ChangeRole(role)
    refreshData();
  };



    return (
      <Container>
        <Wrapper>
          <Title>{employee.username} :</Title>
          {employee.role===ADMIN?
            <CurrentButton>ADMIN</CurrentButton>:
            <StyledButton onClick={() => handleClick(ADMIN)}>ADMIN</StyledButton>}
          {employee.role===EMPLOYEE?
            <CurrentButton>EMPLOYEE</CurrentButton>:
            <StyledButton onClick={() => handleClick(EMPLOYEE)}>EMPLOYEE</StyledButton>}
          {employee.role===CUSTOMER?
            <CurrentButton>CUSTOMER</CurrentButton>:
            <StyledButton  onClick={() => handleClick(CUSTOMER)}>CUSTOMER</StyledButton>}
        </Wrapper>
      </Container>
  )};
  
  export default EditEmployee;
import React, { useEffect, useState } from 'react';
import {Container, CenterContainer, Wrapper} from './styled'
import EmployeesApi from "../../api/EmployeesApi";
import EditEmployee from "../../components/EditEmployee"

const Employees = () => {
  const [employees, setEmployees] = useState([])

  const getEmployees = () => {
    EmployeesApi.getAll()
    .then(response => {
      setEmployees(response.data.sort(({ id: previousID }, { id: currentID }) => previousID - currentID));
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => {
    getEmployees();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <Wrapper>
          {employees.map(employee => (
            <EditEmployee key={employee.id} employee={employee} refreshData={getEmployees}/>
          ))}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Employees;
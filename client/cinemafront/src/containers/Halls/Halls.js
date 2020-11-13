import React, { useEffect, useState } from 'react';
import AddHall from "../../components/AddHall"
import {Container, Wrapper,Title, List, StyledLink} from './styled'
import { CenterContainer } from './styled';
import HallsApi from "../../api/HallsApi";

const Halls = () => {
  const [halls, setHalls] = useState([])

  const deleteHall = id => {
    HallsApi.remove(id)
    .then(response => {
      console.log(response)
      getHalls();
    })
    .catch(error => {
      console.log(error);
    });
  }

  const getHalls = () => {
    HallsApi.getAll()
    .then(response => {
      setHalls(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => {
    getHalls();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <AddHall refreshData={getHalls}/>
        <Wrapper>
        <Title>Sale kinowe:</Title>
          {halls.length?
            <List>
              {halls.map(hall => (
                <StyledLink key={hall.id} to={'/halls/' + hall.id}>
                  <li>
                  {hall.name}
                  </li>
                </StyledLink>
              ))}
            </List>
            :
            <Title>Brak sal!</Title>}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Halls;
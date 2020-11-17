import React, { useEffect, useState } from 'react';
import AddShowing from "../../components/AddShowing"
import {Container, CenterContainer, Wrapper, Title, List, Row, StyledLink, DeleteIcon} from './styled'
import ShowingsApi from "../../api/ShowingsApi";
import AuthService from "../../components/AuthService"
import {ADMIN, EMPLOYEE} from "../../utils/Roles"

const Showings = () => {
  const [showings, setShowings] = useState([])

  const getShowings = () => {
    ShowingsApi.getAll()
    .then(response => {
      setShowings(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const deleteShowing = (id) => {
    ShowingsApi.remove(id)
    .then(response => {
      getShowings();
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => {
    getShowings();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <Wrapper>
        <Title>Seanse kinowe:</Title>
          {showings.length?
            <List>
              {showings.map(showing => (
                <Row key={showing.id}>
                  <StyledLink to={'/reservation/' + showing.id} > 
                    {showing.hall.name} - {showing.movie.title} - czas trwania filmu: {showing.movie.duration}
                  </StyledLink>
                  {AuthService.getUserRole()===ADMIN||AuthService.getUserRole()===EMPLOYEE?<DeleteIcon onClick={() => deleteShowing(showing.id)}/>:null}
                </Row>
              ))}
            </List>:
            <Title>Brak seansów!</Title>}
        </Wrapper>
        {AuthService.getUserRole()===ADMIN||AuthService.getUserRole()===EMPLOYEE?<AddShowing refreshData={getShowings}/>:null}
      </CenterContainer>
    </Container>
)};

export default Showings;

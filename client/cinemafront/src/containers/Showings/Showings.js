import React, { useEffect, useState } from 'react';
import AddShowing from "../../components/AddShowing"
import {Container, CenterContainer, Wrapper,Title, List, Row, StyledLink, DeleteIcon} from './styled'
import ShowingsApi from "../../api/ShowingsApi";

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
                <Row>
                  <StyledLink key={showing.id} to={'/reservation/' + showing.id} > 
                    {showing.hall.name} - {showing.movie.title} - czas trwania filmu: {showing.movie.duration}
                  </StyledLink>
                  <DeleteIcon onClick={() => deleteShowing(showing.id)}/>
                </Row>
              ))}
            </List>:
            <Title>Brak seansów!</Title>}
        </Wrapper>
        <AddShowing refreshData={getShowings}/>
      </CenterContainer>
    </Container>
)};

export default Showings;

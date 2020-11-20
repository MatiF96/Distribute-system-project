import React, {useEffect, useState} from 'react';
import {Container,CenterContainer, Wrapper, Item} from './styled'
import ShowingsApi from "../../api/ShowingsApi";
import {withRouter} from "react-router-dom"
import AddReservation from "../../components/AddReservation"

const Reservation = (props) => {
  
  const [showing, setShowing] = useState(null)

  const getShowing = id => {
    ShowingsApi.get(id)
    .then(response => {
      setShowing(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => getShowing(props.match.params.id), [])
  
  return (
    <Container>
      <CenterContainer>
        <Wrapper>
          <Item >Rezerwujesz miejsca na film: {showing?showing.movie.title:null}</Item>
          {showing?<AddReservation showing={showing} />:null}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default withRouter(Reservation);
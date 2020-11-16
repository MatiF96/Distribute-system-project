import React, {useEffect, useState} from 'react';
import {Container,CenterContainer, Wrapper, Item, BlockedItem, Alert} from './styled'
import ShowingsApi from "../../api/ShowingsApi";
import ReservationsApi from "../../api/ReservationApi";
import * as signalR from '@microsoft/signalr';
import AuthService from "../AuthService"
import {withRouter} from "react-router-dom"

const Reservation = (props) => {
  
  const [showing, setShowing] = useState(null)
  const [blocked, setBlocked] = useState(false);
  const [editing, setEditing] = useState(false);

  const hubConnection = new signalR.HubConnectionBuilder().withUrl("/reservation").build();

  const getShowing = id => {
    ShowingsApi.get(id)
    .then(response => {
      setShowing(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const handleClick = () =>
  {
    if(AuthService.getCurrentUser())
    {
      let data = {
        userId: AuthService.getCurrentUser().id,
        showingId: showing.id
      }
  
      ReservationsApi.create(data)
      .then(() => {
        setEditing(true)
      })
      .catch(e => {
        console.log(e);
      });
    }
  }

  useEffect(() => {
    getShowing(props.match.params.id)
    //console.log(showing.movie.title)

    hubConnection.start();
    hubConnection.on("OnSeatsChanged", () => {
      console.log("Ktoś rezerwuje... Odczekaj 10 sekund")
      setBlocked(true)
      setTimeout(() => {
        setBlocked(false)
        setEditing(false)
      },5000)
    })
    // eslint-disable-next-line
  }, [])
  
  return (
    <Container>
      <CenterContainer>
        <Wrapper>
          {blocked?
          <BlockedItem>Rezerwacja{!editing?", poczekaj, aż ktoś inny zakończy":null}</BlockedItem>:
          <Item onClick={handleClick}>Kliknij, żeby zarezerwować bilet na: {showing?showing.movie.title:null}</Item>}
          {editing?<Alert>Teraz mozesz edytowac!</Alert>:null}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default withRouter(Reservation);
import { Container, CenterContainer, Title, List, Seat, StyledButton, Display } from './styled';
import { useEffect, useState } from 'react';
import ReservationApi from "../../api/ReservationApi";
import ShowingsApi from "../../api/ShowingsApi"
import AuthService from "../../components/AuthService"
import * as signalR from '@microsoft/signalr';

const SEATSAMOUNT = 50;

const AddReservation = ({showing}) => {
  const [seats, setSeats] = useState([]);
  const [hall, setHall] = useState([]);

  const handleReserve = (seatId) => {
    let data = {
      showingId: showing.id,
      userId: AuthService.getUserId(),
      seat: seatId
    };
    console.log(data)

    ReservationApi.create(data)
    .then(() => {
      loadSeats()
    })
    .catch(e => {
    console.log(e);
    });
  }

  const handleSubmit= () => {
    let data = {
      showingId: showing.id,
      userId: AuthService.getUserId(),
    };

    ReservationApi.complete(data)
    .then(() => {
      console.log("Zatwierdzono rezerwacje")
    })
    .catch(e => {
    console.log(e);
    });
  }

  const loadSeats = () => {

    ShowingsApi.getTakenSeats(showing.id)
    .then((response) => {

      let takenSeats = response.data.map(item => item.number)
      let newSeats = []
      for(let i = 1; i <= SEATSAMOUNT; i++)
      {
        if(takenSeats.includes(i))
        {
          newSeats.push({id: i, isTaken: true})
        }
        else{
          newSeats.push({id: i, isTaken: false})
        }
      }
      setSeats(newSeats)

    })
    .catch(e => {
    console.log(e);
    });
  }

  const createHall = () => {
    setHall([])
    seats.map(seat => 
    setHall(prevState => [...prevState, <Seat isTaken={seat.isTaken} key={`seat_${seat.id}`} onClick={() => handleReserve(seat.id)}>{seat.id}</Seat>]))
  }

  const hubConnection = new signalR.HubConnectionBuilder().withUrl("/reservation").build();

  useEffect(() => {
    hubConnection.start();
    hubConnection.on("OnSeatsChanged", () => {
      console.log("Ktoś zarezerwowal... Odswiezanie")
      loadSeats()
    })
    // eslint-disable-next-line
  }, [])

  useEffect(loadSeats, [])

  useEffect(createHall, [seats])

  return (
  <Container>
    <CenterContainer>
      <Title>Wybierz miejsca na sali:</Title>
      <Display>EKRAN</Display>
      <List>
        {hall}
      </List>
      <StyledButton onClick={handleSubmit}> Zatwierdzam </StyledButton>
    </CenterContainer>
  </Container>
  )};
  
  export default AddReservation;
import { Container, CenterContainer, Title, List, Seat, StyledButton } from './styled';
import { useEffect, useState } from 'react';
import ReservationApi from "../../api/ReservationApi";
import AuthService from "../../components/AuthService"

const SEATSAMOUNT = 50;

const AddReservation = () => {
  const [seats, setSeats] = useState([]);
  const [checked, setChecked] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      showingId: 1,
      userId: AuthService.getUserId(),
      seat: checked
    };

    ReservationApi.create(data)
    .then(() => {

    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleSeatClick= (id) => {
    console.log(id) //trzeba dodac do checked, potem do api
  }

  const loadSeats = () => {
    const hall = [];

    for(let i = 1; i <= SEATSAMOUNT; i++)
    {
    hall.push(<Seat key={`place_${i}`} onClick={() => handleSeatClick(i)}>{i}</Seat>)
    }

    setSeats(hall)
  }


  useEffect(() =>{
    loadSeats()
  },[])
    return (
    <Container>
      <CenterContainer>
        <Title>Wybierz miejsca na sali:</Title>
        <List>
          {seats}
        </List>
        <StyledButton> Zatwierdzam </StyledButton>
      </CenterContainer>
    </Container>
  )};
  
  export default AddReservation;
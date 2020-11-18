import { Container, Title, StyledForm, StyledInput, StyledButton } from './styled';
import { useState } from 'react';
import HallsApi from "../../api/HallsApi";

const AddHall = ({ refreshData }) => {
  const [name, setName] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      name: name
    };

    HallsApi.create(data)
    .then(() => {
      refreshData()
      setName("")
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleChange = (e) => {
    setName(e.target.value)
  }
    return (
      <Container>
        <Title>Dodaj salę</Title>
          <StyledForm onSubmit={handleSubmit}>
            <StyledInput
              type="text"
              id="title"
              name="title"
              value={name}
              onChange={handleChange}
              placeholder="Nazwa sali"
              required
            />
            <StyledButton type="submit"> Dodaj </StyledButton>
          </StyledForm>
      </Container>
  )};
  
  export default AddHall;
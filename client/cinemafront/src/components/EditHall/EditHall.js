import {
  Container,
  Title,
  StyledForm,
  StyledInput,
  StyledButton 
} from './styled';
import { useEffect, useState } from 'react';
import HallsApi from "../../api/HallsApi";

const EditHall = ({ currentHall, refreshHall }) => {
  const [name, setName] = useState('');

  useEffect(() =>{
    setName(currentHall.name)
    // eslint-disable-next-line
  },[])

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      name: name
    };

    HallsApi.update(currentHall.id,data)
    .then((res) => {
      refreshHall()
      setName("")
      console.log(res);
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
        <Title>Edytuj salę:</Title>
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
            <StyledButton type="submit"> Edytuj! </StyledButton>
          </StyledForm>
      </Container>
  )};
  
  export default EditHall;
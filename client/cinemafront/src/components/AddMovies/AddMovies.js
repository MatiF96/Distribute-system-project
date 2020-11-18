import { Container, Title, StyledForm, StyledInput, StyledButton } from './styled';
import { useState } from 'react';
import MoviesApi from "../../api/MoviesApi";

const AddMovie = ({ refreshData }) => {
  const [title, setTitle] = useState('');
  const [duration, setDuration] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      title: title,
      duration: parseInt(duration)
    };

    console.log(data)

    MoviesApi.create(data)
    .then(() => {
      refreshData()
      setTitle('')
      setDuration('')
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleChange = (e) => {
    const { target } = e;
    const { name, value } = target;

    name==="title"?
    setTitle(value):
    setDuration(value)
  }
    return (
      <Container>
        <Title>Dodaj film</Title>
          <StyledForm onSubmit={handleSubmit}>
            <StyledInput
              type="text"
              id="title"
              name="title"
              value={title}
              onChange={handleChange}
              placeholder="Nazwa filmu"
              required
            />
            <StyledInput
              type="text"
              id="duration"
              name="duration"
              value={duration}
              onChange={handleChange}
              placeholder="Czas trwania (minuty)"
              required
            />
            <StyledButton type="submit"> Dodaj </StyledButton>
          </StyledForm>
      </Container>
  )};
  
  export default AddMovie;
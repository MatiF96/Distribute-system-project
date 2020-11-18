import { Container, Title, FormContainer, StyledInput, StyledButton } from './styled';
import { useEffect, useState } from 'react';
import MovieApi from "../../api/MoviesApi";


const EditMovie = ({ currentMovie, refreshMovie }) => {
  const [title, setTitle] = useState('');
  const [duration, setDuration] = useState('');

  useEffect(() =>{
    setTitle(currentMovie.title)
    setDuration(currentMovie.duration)
    // eslint-disable-next-line
  },[])

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      title: title,
      duration: parseInt(duration)
    };

    MovieApi.update(currentMovie.id,data)
    .then((res) => {
      refreshMovie()
      setTitle("")
      setDuration("")
      console.log(res);
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
        <Title>Edytuj film:</Title>
        <FormContainer onSubmit={handleSubmit}>
          <StyledInput
            type="text"
            id="title"
            name="title"
            value={title}
            onChange={handleChange}
            placeholder="Nazwa filmu"
          />
          <StyledInput
            type="text"
            id="duration"
            name="duration"
            value={duration}
            onChange={handleChange}
            placeholder="Czas trwania filmu"
          />
          <StyledButton type="submit"> Edit </StyledButton>
         </FormContainer>
      </Container>
  )};
  
  export default EditMovie;
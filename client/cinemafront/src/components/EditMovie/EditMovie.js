import { Container, Title } from './styled';
import { useEffect, useState } from 'react';
import MovieApi from "../../api/MoviesApi";
import Input from '@material-ui/core/Input';
import { Button } from '@material-ui/core';

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
          <form onSubmit={handleSubmit}>
            <Input
              type="text"
              id="title"
              name="title"
              value={title}
              onChange={handleChange}
              placeholder="Nazwa filmu"
            />
            <Input
              type="text"
              id="duration"
              name="duration"
              value={duration}
              onChange={handleChange}
              placeholder="Czas trwania filmu"
            />
            <Button type="submit">Edit</Button>
          </form>
      </Container>
  )};
  
  export default EditMovie;
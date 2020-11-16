import React, { useEffect, useState } from 'react';
import {Container, DeleteIcon, Item, Label, EditLabel, Wrapper} from './styled'
import MovieApi from "../../api/MoviesApi";
import { withRouter } from "react-router-dom"
import EditMovie from '../EditMovie';

const Movie = (props) => {
  const [movie, setMovie] = useState(null)
  const [editing, setEditing] = useState(false)

  const getMovie = id => {
    MovieApi.get(id)
    .then(response => {
      setMovie(response.data);
      console.log(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const deleteMovie = id => {
    MovieApi.remove(id)
    .then(response => {
      props.history.push('/movies')
    })
    .catch(error => {
      console.log(error);
    });
  }

  const handleEditClick = () =>
  {
    setEditing(!editing)
  }

  useEffect(() => {
    let id = props.match.params.id;
    getMovie(id)
    // eslint-disable-next-line
  }, [])
  return (
  <>
    {movie?
    <Container>
      <Wrapper>
        <Item>
          <Label>Id: {movie.id}</Label>
          <Label>Title: {movie.title}</Label>
          <Label>Duration: {movie.duration}</Label>
        </Item>
        <Item>
          <EditLabel onClick={handleEditClick}>Edit</EditLabel>
        </Item>
        <Item>
          <DeleteIcon onClick={() => deleteMovie(movie.id)}/>
        </Item>
      </Wrapper>
      {
        editing?
        <Wrapper>
          <EditMovie currentMovie={movie} refreshMovie={() => getMovie(movie.id)}/>
        </Wrapper>
        :
        null
      }
    </Container>:
    <h2>Loading..</h2>}
  </>
)};

export default withRouter(Movie);

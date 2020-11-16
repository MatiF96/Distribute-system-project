import React, { useEffect, useState } from 'react';
import AddMovies from "../../components/AddMovies"
import {Container, Wrapper,Title, List, StyledLink} from './styled'
import { CenterContainer } from './styled';
import MoviesApi from "../../api/MoviesApi";

const Movies = () => {
  const [movies, setMovies] = useState([])

  const getMovies = () => {
    MoviesApi.getAll()
    .then(response => {
      setMovies(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => {
    getMovies();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <AddMovies refreshData={getMovies}/>
        <Wrapper>
        <Title>Filmy:</Title>
          {movies.length?
            <List>
              {movies.map(movie => (
                <StyledLink key={movie.id} to={'/movies/' + movie.id}>
                  <li>
                  {movie.title} -  {movie.duration} minuty
                  </li>
                </StyledLink>
              ))}
            </List>
            :
            <Title>Brak filmów!</Title>}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Movies;
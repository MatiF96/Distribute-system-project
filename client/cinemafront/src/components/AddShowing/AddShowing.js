import { Container, InnerContainer, Title, List, Item, StyledButton, ClickedItem } from './styled';
import { useState, useEffect } from 'react';
import ShowingsApi from "../../api/ShowingsApi";
import HallsApi from "../../api/HallsApi";
import MoviesApi from "../../api/MoviesApi";

const AddShowing = ({ refreshData }) => {
  const [halls, setHalls] = useState([])
  const [movies, setMovies] = useState([])

  const [currentHall, setCurrentHall] = useState(null)
  const [currentMovie, setCurrentMovie] = useState(null)

  const getHalls = () => {
    HallsApi.getAll()
    .then(response => {
      setHalls(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const getMovies = () => {
    MoviesApi.getAll()
    .then(response => {
      setMovies(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
    movieId: currentMovie,
    hallId: currentHall,
    date: "2020-11-16T08:33:56.530Z"
  }

    //console.log(data);
    ShowingsApi.create(data)
    .then(() => {
      refreshData()
      setCurrentHall(null)
      setCurrentMovie(null)
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleHallsClick = (id) => {
    setCurrentHall(id)
  }

  const handleMoviesClick = (id) => {
    setCurrentMovie(id)
  }

  useEffect(() => {
    getHalls();
    getMovies();
  }, [])

    return (
      <Container>
        <Title>Stwórz seans</Title>
        <InnerContainer>
            {halls.length?
              <List>
                {halls.map(hall => (
                  hall.id===currentHall?
                  <ClickedItem key={hall.id} onClick={() => handleHallsClick(hall.id)}>
                    {hall.name}
                  </ClickedItem>:
                  <Item key={hall.id} onClick={() => handleHallsClick(hall.id)}>
                    {hall.name}
                  </Item>
                ))}
              </List>
              :
              <Title>Brak sal!</Title>}
          {movies.length?
            <List>
              {movies.map(movie => (
                movie.id===currentMovie?
                <ClickedItem key={movie.id} onClick={() => handleHallsClick(movie.id)}>
                  {movie.title} -  {movie.duration} minuty
                </ClickedItem>:
                <Item key={movie.id} onClick={() => handleMoviesClick(movie.id)}>
                  {movie.title} -  {movie.duration} minuty
                </Item>
              ))}
            </List>
            :
            <Title>Brak filmów!</Title>}
        </InnerContainer>
        <StyledButton onClick={handleSubmit}>Dodaj!</StyledButton>
      </Container>
  )};
  
  export default AddShowing;
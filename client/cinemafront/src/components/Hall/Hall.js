import React, { useEffect, useState } from 'react';
import {Container} from './styled'
import HallsApi from "../../api/HallsApi";

const Hall = (props) => {
  const [hall, setHall] = useState(null)

  const getHall = id => {
    HallsApi.get(id)
    .then(response => {
      setHall(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  useEffect(() => {
    let id = props.match.params.id;
    getHall(id)
    // eslint-disable-next-line
  }, [])
  return (
  <Container>
      {hall?
      <h2>Hall: {hall.name}</h2>:
      <h2>Loading</h2>}
  </Container>
)};

export default Hall;

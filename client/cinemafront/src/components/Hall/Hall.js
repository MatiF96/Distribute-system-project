import React, { useEffect, useState } from 'react';
import {Container, DeleteIcon, Item, Label, EditLabel, Wrapper} from './styled'
import HallsApi from "../../api/HallsApi";
import { withRouter } from "react-router-dom"
import EditHall from '../EditHall/EditHall';

const Hall = (props) => {
  const [hall, setHall] = useState(null)
  const [editing, setEditing] = useState(false)

  const getHall = id => {
    HallsApi.get(id)
    .then(response => {
      setHall(response.data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  const deleteHall = id => {
    HallsApi.remove(id)
    .then(response => {
      props.history.push('/halls')
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
    getHall(id)
    // eslint-disable-next-line
  }, [])
  return (
  <>
    {hall?
    <Container>
      <Wrapper>
        <Item>
          <Label>Id: {hall.id}</Label>
          <Label>Name: {hall.name}</Label>
        </Item>
        <Item>
          <EditLabel onClick={handleEditClick}>Edit</EditLabel>
        </Item>
        <Item>
          <DeleteIcon onClick={() => deleteHall(hall.id)}/>
        </Item>
      </Wrapper>
      {
        editing?
        <Wrapper>
          <EditHall currentHall={hall} refreshHall={() => getHall(hall.id)}/>
        </Wrapper>
        :
        null
      }
    </Container>:
    <h2>Loading..</h2>}
  </>
)};

export default withRouter(Hall);

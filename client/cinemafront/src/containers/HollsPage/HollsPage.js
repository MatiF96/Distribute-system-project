import React, { useEffect, useState } from 'react';
import Navbar from '../../components/Navbar'
import axios from 'axios';
import AddHall from "../../components/AddHall"
import {Container, Wrapper,Title, List, Item} from './styled'
import { CenterContainer } from './styled';
import DeleteOutlineOutlinedIcon from '@material-ui/icons/DeleteOutlineOutlined';

const Halls = () => {
  const [halls, setHalls] = useState([])

  const DeleteHall = (id) => {

    axios
    .delete(`api/Hales/${id}`)
    .then(res => {
      console.log("deleted",id)
      GetData();
    })
    .catch(err => {
      console.log(err)
    })
  }

  const GetData = () => {
    axios
    .get('api/Hales')
    .then(res => {
      console.log(res.data)
      setHalls(res.data)
    })
    .catch(err => {
      console.log(err)
    })
  }
  useEffect(() => {
    GetData();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <AddHall refreshHalls={GetData} />
        <Wrapper>
        <Title>Sale kinowe:</Title>
          {halls.length?
            (<List>
              {halls.map(hall => (
                <Item key={hall.id} >{hall.name} <DeleteOutlineOutlinedIcon fontSize="large" onClick={() => DeleteHall(hall.id)}/></Item>
              ))}
            </List>)
            :
            <Title>Brak sal!</Title>}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Halls;
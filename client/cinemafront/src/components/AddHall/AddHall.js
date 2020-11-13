import Input from '@material-ui/core/Input';
import { Container, Title } from './styled';
import { useState } from 'react';
import HallsApi from "../../api/HallsApi";

const AddHall = ({ refreshData }) => {
  const [name, setName] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      name: name
    };

    HallsApi.create(data)
    .then(() => {
      refreshData()
      setName("")
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
        <Title>Dodaj salę</Title>
          <form onSubmit={handleSubmit}>
            <Input
              type="text"
              id="title"
              name="title"
              value={name}
              onChange={handleChange}
              placeholder="Nazwa sali"
            />
          </form>
      </Container>
  )};
  
  export default AddHall;
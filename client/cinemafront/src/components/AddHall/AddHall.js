import Input from '@material-ui/core/Input';
import { Title } from './styled';
import axios from 'axios';
import { useState } from 'react';
import {Container} from './styled'

const AddHall = ({refreshHalls}) => {
  const [name, setName] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault()
    
    const hall = {
      name: name
    }

    axios
      .post('api/Hales', hall)
      .then(response => {
        console.log(response)
        refreshHalls();
        setName("");
      })
      .catch(error => {
        console.log(error)
      })
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
              name="title"
              value={name}
              placeholder="Nazwa sali"
              onChange={handleChange}
            />
          </form>
      </Container>
  )};
  
  export default AddHall;
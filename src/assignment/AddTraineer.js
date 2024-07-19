import React, { Component } from 'react'
import axios from 'axios'
class AddTraineer extends Component {
    constructor(props) {
        super(props)
      
        this.state = {
          name:'',
          phoneNumber:'',
          role:""
                    
        }
      }
  changeHandler=event=>{
      this.setState({
          [event.target.name]:event.target.value
      })
  }
  submitHandler=event=>{
      event.preventDefault()
  axios.post(`https://localhost:7276/api/Trainers/AddTrainer`,this.state)
  .then(response=>{
      console.log(response)
  })
  .catch(error=>{
      console.log(error)
  })
  }
      
    render() {
      const {name,phoneNumber,role}=this.state
      return (
        <form onSubmit={this.submitHandler} className='forms'>
          <label>Name</label>
          <input type='text' name='name' value={name}  onChange={this.changeHandler}/><br/>
          <label>Phone Number</label>
          <input  type='text'name='phoneNumber' value={phoneNumber} onChange={this.changeHandler} /><br/>
          <label>Role</label>
          <input type='text' name='role' value={role} onChange={this.changeHandler} /><br/>
          <button type='submit'>Add Trainer</button>
        </form>
      )
    }
}

export default AddTraineer

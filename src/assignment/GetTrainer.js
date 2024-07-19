import React, { Component } from 'react'
import axios from 'axios'
class GetTrainer extends Component {
    constructor(props) {
        super(props)
      
        this.state = {
          trainers:[] 
        }
      }
      componentDidMount(){
          axios.get(`https://localhost:7276/api/Trainers/GetAllTrainers`)
          .then(response=>{
              console.log(response.data)
              this.setState({
                  trainers:response.data
              })
          })
          .catch(error=>{
              console.log(error)
          })
      }
    render() {
      const {trainers}=this.state
      return (
        <div>
          <h1>Trainers lists</h1>
          <table className='center'>
              <thead>
  
                 <tr>      
                  <th>Name</th>
                  <th>PhoneNumer</th>
                  <th>Role</th>
                  </tr>
              </thead>
         <tbody>
         <tr>
              {
              trainers.map(trainer=>
               <div><th>{trainer.name}</th>
               <th>{trainer.phoneNumber}</th>
               <th>{trainer.role}</th>
  
               </div>
               )
              }
               </tr>
         </tbody>
  
          </table>
  
          
        </div>
      )
    }
}

export default GetTrainer

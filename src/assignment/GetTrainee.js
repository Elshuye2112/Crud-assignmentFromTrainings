import React, { Component } from 'react'
import axios from 'axios'
import './style.css'
class GetTrainee extends Component {
    constructor(props) {
        super(props)
      
        this.state = {
          trainees:[] 
        }
      }
      componentDidMount(){
          axios.get(`https://localhost:7276/api/Trainee/GetAllTranees`)
          .then(response=>{
              console.log(response.data)
              this.setState({
                  trainees:response.data
              })
          })
          .catch(error=>{
              console.log(error)
          })
      }
    render() {
      const {trainees}=this.state
      return (
        <div>
          <h1>Trainee lists</h1>
          <table className='center'>
              <thead>
  
                 <tr>      
                  <th>Name</th>
                  <th>PhoneNumer</th>
                  <th>Department</th>
                  </tr>
              </thead>
         <tbody>
         <tr>
              {
              trainees.map(trainee=>
               <div><th>{trainee.name}</th>
               <th>{trainee.phoneNumber}</th>
               <th>{trainee.department}</th>
  
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

export default GetTrainee

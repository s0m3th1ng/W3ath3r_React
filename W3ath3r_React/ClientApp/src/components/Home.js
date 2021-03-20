import React, { Component } from 'react';
import { Content } from './Content';
import { Journal } from './Journal';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;
  
  constructor() {
      super();
      this.state = {
          btnDisabled: true,
          input: "",
          json: "",
          journalBlocksJSON: [],
      }
  }

  render () {
    const btnDisabled = this.state.btnDisabled;
      
    return (
      <div className="pb-3">
        <div className="text-center">
          <h1 className="display-4">Welcome!<br/>Enter your ZIP-code</h1>
        </div>
        <div className="d-flex justify-content-between">
          <div>
            <div className="formDiv">
              <label className="col-form-label">Example: 94110</label>
              <input id="zipcode" className="input-group-text" type="text" maxLength="5" onInput={this.checkInput.bind(this)}/>
              <button id="submit" className="btn btn-dark" type="submit" onClick={this.fetchForm.bind(this)} disabled={btnDisabled}>Submit</button>
            </div>
              
            <Content json={this.state.json}/>
            
          </div>
            
          <Journal journalBlocksJSON={this.state.journalBlocksJSON}/>
          
        </div>
      </div>
    );
  }

  checkInput(e) {
      const zipRegex = /^\d{5}$/;
      const value = e.target.value;
      this.setState({
          btnDisabled: !value.match(zipRegex),
          input: e.target.value,
      });
  }
  
  fetchForm() {
      const url = `Home/Weather?zipcode=${this.state.input}`;
      fetch(url)
          .then(response => response.json())
          .then(responseJSON => {
              const maxJournalLength = 3;
              const journalBlocks = this.state.journalBlocksJSON;
              
              if ((this.state.json != null) && (this.state.json !== "")) {
                  journalBlocks.push(this.state.json);
              }
              if (journalBlocks.length > maxJournalLength) {
                  journalBlocks.shift()
              }
              
              this.setState({
                  journalBlocksJSON: journalBlocks,
                  json: responseJSON,
              })
          });
  }
}
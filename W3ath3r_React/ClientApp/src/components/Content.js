import React, { Component } from 'react';

import './Content.css';

export class Content extends Component {
    
    render () {
        const error = "Sorry, zip not found";
        const json = this.props.json;
        const style = {
            borderTopWidth: 3,
            borderBottomWidth: 3,
        }
        let template = null;

        if ((json === null) || (json !== "")) {
            if (json === null) {
                template =
                    <div id="content" style={style}>
                      <p>{error}</p>
                    </div>;
            } else {
                template =
                    <div id="content" style={style}>
                      <p>City: {json.cityName}</p>
                      <p>Temperature: {json.temp}℃</p>
                      <p>Time Zone: {json.timezoneName}</p>
                    </div>;
            }
        }
        return template;
              {/*TODO:  try to remove closing tags
                        Animate
                        Ask about routing
                        Clear all unnecessary
                        Consts out
              */}
    }
}
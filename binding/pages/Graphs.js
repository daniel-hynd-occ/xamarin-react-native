/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import {
    createStackNavigator,
  } from 'react-navigation';
  
  import React, { Component } from 'react';
  import {
    StyleSheet,
    View,Dimensions
  } from 'react-native';
  import { VictoryLine, VictoryChart, VictoryTheme } from "victory-native";
  
  const width = Dimensions.get('window').width;
  
  class Graphs extends Component {
    static navigationOptions = {
        title: 'Graph example',
      };
    constructor() {
      super();
      this.state = {
        sampleData: [
          { x: 0, y: 100 },
          { x: 1, y: 165 },
          { x: 2, y: 150 },
          { x: 3, y: 290 },
          { x: 4, y: 190 },
          { x: 5, y: 100 },
          { x: 6, y: 165 },
          { x: 7, y: 150 },
          { x: 8, y: 290 },
          { x: 9, y: 190 },
          { x: 10, y: 100 },
          { x: 11, y: 165 },
          { x: 12, y: 150 },
          { x: 13, y: 290 },
          { x: 14, y: 190 }, 
          { x: 15, y: 100 },
          { x: 16, y: 165 },
          { x: 17, y: 150 },
          { x: 18, y: 290 },
          { x: 19, y: 190 }
        ]
      }
      this._updateSampleData = this._updateSampleData.bind(this);
    }
    componentDidMount() {
      setInterval(() => {
        this._updateSampleData();
      }, 200);
    }
    _updateSampleData() {
      let sampleData = this.state.sampleData;
      sampleData.map((item, i) => {
        item.y = Math.floor(Math.random() * 300) + 1
      });
      this.setState({
        sampleData: sampleData
      })
    }
    render() {
      return (
        <View style={styles.container}>
          <VictoryChart width={width} theme={VictoryTheme.material} domain={{ x: [0, 19], y: [0, 300] }}>
            <VictoryLine data={this.state.sampleData} x="x" y="y" />
          </VictoryChart> 
        </View>
      );
    }
  }
  
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
      backgroundColor: '#F5FCFF',
      padding: 20,
      margin: 10
    }
  });
  
export default Graphs;
  
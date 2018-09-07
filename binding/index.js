/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
  Alert,
  AppRegistry,
  Platform,
  StyleSheet,
  Text,
  View,
  Button,
  NativeModules
} from 'react-native';
import Svg,{
	Circle,
    Ellipse,
    G,
    LinearGradient,
    RadialGradient,
    Line,
    Path,
    Polygon,
    Polyline,
    Rect,
    Symbol,
    Use,
    Defs,
    Stop
} from 'react-native-svg'

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' +
    'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' +
    'Shake or press menu button for dev menu',
});

class RNHelloWorld extends Component<{}> {
  _onPressToastButton() {
	  NativeModules.ToastExample.show("HEYYYY");
  }
	
  _onPressCallbackButton() {
	  NativeModules.RNG.nextAsString(
      (err)=>{
        console.error(err);
      },
      (x) => {
        Alert.alert(x);
      }
    );
  }

  _onPressPromiseButton = async function() {
    try{
      var x = await NativeModules.RNG.nextNegative(10,20);
      Alert.alert('Number is:' + x);
    }
    catch(e)
    {
      console.error(e);
    }
  }
  render() {
	
    return (
      <View style={styles.container}>
        <Text style={styles.welcome}>
          Hey there! Wassup?
        </Text>
        <Text style={styles.instructions}>
          To get started, edit App.js
        </Text>
        <Text style={styles.instructions}>
          {instructions}
        </Text>
        <Text>
          Test ? ! www
        </Text>
		<Button
          onPress={this._onPressToastButton}
          title="Toast"
          color="#2267d6"
        />
        <Button
          onPress={this._onPressCallbackButton}
          title="Callback"
          color="#841584"
        />
        <Button
          onPress={this._onPressPromiseButton}
          title="Promise"
          color="#4da058"
        />
		<Svg 
			height="100"
			width="100">
			<Circle
				cx="50"
				cy="50"
				r="45"
				stroke="blue"
				strokeWidth="2.5"
				fill="green"
			/>
			<Rect
				x="15"
				y="15"
				width="70"
				height="70"
				stroke="red"
				strokeWidth="2"
				fill="yellow"
			/>
		</Svg>
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
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

// Module name
AppRegistry.registerComponent('MyReactNativeApp', () => RNHelloWorld);

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
    Alert,
    AppRegistry,
    Platform,
    StyleSheet,
    Text,
    View,
    Button,
    NativeModules,
    ART, Dimensions
  } from 'react-native';

  const instructions = Platform.select({
    ios: 'Press Cmd+R to reload,\n' +
      'Cmd+D or shake for dev menu',
    android: 'Double tap R on your keyboard to reload,\n' +
      'Shake or press menu button for dev menu',
  });
  
  class NativeModulesExample extends Component {
    static navigationOptions = {
      title: 'Native module example',
    };
    _onPressToastButton() {
        NativeModules.ToastExample.show('hi');
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
            <Text>
            {instructions}
            </Text>
            <Text>
            Test ? !
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
    }
  });
  
export default NativeModulesExample;
  
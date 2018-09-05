import {
    createStackNavigator,
  } from 'react-navigation';
  
  import React, { Component } from 'react';
  import {
    View,
    Button,
    StyleSheet
  } from 'react-native';

class HomeScreen extends React.Component {
    static navigationOptions = {
      title: 'Home Screen',
    };
    render() {
      const { navigate } = this.props.navigation;
      return (
        <View style={styles.container}>
          <Button
            title="Go to Graphs"
            color="pink"
            onPress={() =>
              navigate('Graphs')
            }
          />
          <Button
            title="Go to Native Module Example"
            color="lightblue"
            onPress={() =>
              navigate('NativeModulesExample')
            }
          />
        </View>
      );
    }
  }
  
  
  
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      justifyContent: 'center',
      backgroundColor: 'white'
    }
  });

  export default HomeScreen;
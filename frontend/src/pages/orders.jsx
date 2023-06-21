import React from "react";
import { Text, Input, HStack, Box, VStack, Select} from "@chakra-ui/react";
import { Button, ButtonGroup } from '@chakra-ui/react'
import Navbar from "../components/Navbar";
import { FormControl,FormLabel,NumberDecrementStepper,NumberIncrementStepper,NumberInput,NumberInputStepper,NumberInputField} from '@chakra-ui/react'
function Orders() {
  return (
    <>
      <Navbar />
        <VStack spacing='24px'>
      <HStack spacing='24px'>
      <FormControl>
  <FormLabel>Product Name</FormLabel>
  <Input type='text' />
</FormControl>
      <FormControl>
  <FormLabel>Quantity</FormLabel>
  <NumberInput max={1000} min={1}>
    <NumberInputField />
    <NumberInputStepper>
      <NumberIncrementStepper />
      <NumberDecrementStepper />
    </NumberInputStepper>
  </NumberInput>
</FormControl>
      </HStack>
      <HStack spacing='24px'>
      <Text fontSize='1xl'color='black'align={"left"}> Category</Text> 
      <Select placeholder='Select option'>
  <option value='option1'>Option 1</option>
  <option value='option2'>Option 2</option>
  <option value='option3'>Option 3</option>
</Select>  
      </HStack> 
      <HStack>
      <FormControl>
  <FormLabel>Price</FormLabel>
  <NumberInput max={500000} min={1}>
    <NumberInputField />
    <NumberInputStepper>
      <NumberIncrementStepper />
      <NumberDecrementStepper />
    </NumberInputStepper>
  </NumberInput>
</FormControl>
      </HStack>
      <VStack>
      <HStack>
      <Text fontSize='1xl'color='black'align={"left"}> Supplier</Text> 
      <FormControl>
  <Input type='text' size='md'height='48px' width='200px'/>
</FormControl>
</HStack>
      </VStack>
      <Button colorScheme='blue'align='bottomright'>Submit</Button>
      </VStack>
    </>
  );
}

export default Orders;

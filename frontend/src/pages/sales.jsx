import React, { useState } from "react";
import Navbar from "../components/Navbar";
import ReactDOM from "react-dom/client";
import {
  Box,
  Text,
  Square,
  Flex,
  Spacer,
  Input,
  InputGroup,
  InputLeftElement,
  Stack,
  Button,
  VStack,
  HStack,
} from "@chakra-ui/react";
import {
  FormControl,
  FormLabel,
  NumberDecrementStepper,
  NumberIncrementStepper,
  NumberInput,
  NumberInputStepper,
  NumberInputField,
} from "@chakra-ui/react";
import PurchaseEntry from "../components/PurchaseEntry";
function Sales() {
  const [productName, setProductName] = useState("");
  const [quantity, setQuantity] = useState(1);
  const [purchaseEntries, setPurchaseEntry] = useState([]);

  function changeProductName(e) {
    setProductName(e.target.value);
  }
  function changeQuantity(value) {
    setQuantity(value);
  }

  function addPurchaseEntry(name, quantity) {
    setPurchaseEntry((prevEntries) => [
      ...prevEntries,
      <PurchaseEntry key={name} name={name} quantity={quantity} />,
    ]);
  }

  return (
    <>
      <Navbar />
      <Flex color="gray.300">
        <Square bg="white" size="600px">
          <VStack spacing="24px">
            <HStack>
              <VStack spacing={0} align="stretch">
                <FormControl>
                  <FormLabel color={"black"}>ADD ITEM</FormLabel>
                  <Input
                    type="text"
                    name="productName"
                    value={productName}
                    onChange={changeProductName}
                  />
                </FormControl>
              </VStack>
              <FormControl>
                <FormLabel color={"black"}>Quantity</FormLabel>
                <NumberInput
                  max={1000}
                  min={1}
                  value={quantity}
                  onChange={changeQuantity}
                >
                  <NumberInputField />
                  <NumberInputStepper>
                    <NumberIncrementStepper />
                    <NumberDecrementStepper />
                  </NumberInputStepper>
                </NumberInput>
              </FormControl>
            </HStack>
            <Button
              size="md"
              height="48px"
              width="200px"
              border="2px"
              borderColor="green.500"
              onClick={() => addPurchaseEntry(productName, quantity)}
            >
              {" "}
              ADD
            </Button>
          </VStack>
        </Square>
        <Spacer />
        <Square bg="gray.300" size="600px">
          <VStack>{purchaseEntries}</VStack>
        </Square>
      </Flex>
    </>
  );
}

export default Sales;

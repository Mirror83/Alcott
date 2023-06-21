import React from 'react';
import { Box, HStack, Text } from '@chakra-ui/react';

function PurchaseEntry({name, quantity}) {
  return (
    <>
    <Box bg='black' w='100%' p={4} color='white'>
  <HStack spacing={'24'}>
    <Text color={'white'}>{name ? name : "" }</Text>
    <Text color={'white'}>{quantity ? quantity : 1}</Text>
    </HStack>
</Box>
    </>
  )
}

export default PurchaseEntry
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 * https://leetcode.com/submissions/detail/771360083/
 */
public class Solution {
    //as if you're adding by hand
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        int carry = 0;
        int sum = l1.val + l2.val;
        if(sum > 9){
            carry = 1;
            sum = sum % 10;
        }
        else{
            carry = 0;
        }
        l1 = l1.next;
        l2 = l2.next;
        
        ListNode tmp = new ListNode(sum);
        ListNode nxt = tmp;
        
        while(l1 != null && l2 != null){
            
            sum = l1.val + l2.val + carry;

            int[] what = sumAndCarry(sum, carry);
            sum = what[0];
            carry = what[1];
            
            nxt.next = new ListNode(sum);
            l1 = l1.next;
            l2 = l2.next;
            nxt = nxt.next;
            
        }
                
        if(l1 == null){
            
            while(l2 != null){
                int place = l2.val + carry;
                int[] what = sumAndCarry(place, carry);
                place = what[0];
                carry = what[1];
                nxt.next = new ListNode(place);
                l2 = l2.next;
                nxt = nxt.next;
            }
            
        }
        else if(l2 == null){
            
            while(l1 != null){
                int place = l1.val + carry;
                int[] what = sumAndCarry(place, carry);
                place = what[0];
                carry = what[1];
                nxt.next = new ListNode(place);
                l1 = l1.next;
                nxt = nxt.next;
            }
            
        }
            
        if(carry > 0){
            nxt.next = new ListNode(1);
            nxt = nxt.next;
        }
            
        
        return tmp;
        
        
    }
    
    public int[] sumAndCarry(int sum, int carry){
        if(sum > 9){
            carry = 1;
            sum = sum % 10;
        }
        else{
            carry = 0;
        }
        int[] ret = new int[2];
        ret[0] = sum;
        ret[1] = carry;
        return ret;
    }
    

}

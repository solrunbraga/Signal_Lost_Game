VAR family_photo_unlocked = false
VAR sister_photo_unlocked = false
VAR mom_unlocked = false



=== Beginning ===
Hey, it's been a long day. I'm going to bed now. I'll see you tomorrow, right? #speaker:Sasha
* [Yeah, see you tomorrow. Good night.]
    Good night! #speaker:Sasha
        -> END

* [Why are you going to bed this early?]
    I'm tired, Lucy. Long day tomorrow. Night. #speaker:Sasha
    ** [What is happening tomorrow?]
        Oh, nothing. Never mind. #speaker:Sasha
            -> END

//player goes to bed 

//player wakes up and sister is gone 
//player can pick up phone and exit the room

===Ghost===
//player meets ghost outside hotel
Hello, how can I help you? #speaker:Ghost

* [I'm looking for my sister. Have you seen her?]
    What does your sister look like? #speaker:Ghost

    ** [Short dark hair and green eyes.]
        Ahh, her. Yes, I saw her a few hours ago. #speaker:Ghost

        *** [Did you see where she went?]
            I saw her walk to the park. #speaker:Ghost
            -> END

* [I don't need any help.]
    Very well. #speaker:Ghost
    -> END

//player now starts to look for clues

===YoungBoy===
Who are you? My mom said I shouldn't talk to strangers. #speaker: Young Boy
*[I'm just looking for someone]
    Who are you looking for? Did they get lost? I get lost sometimes, that's why my mom tells me to wait for her. #speaker: Young Boy
    **[I'm looking for my sister]
        Hmm, I'm not supposed to talk to strangers, but if my sister was lost I think she would be scared.#speaker: Young Boy
        ***[Yes, she is probably very scared]
                I did see a girl here earlier, she was sitting on the bench crying, but then she just left.#speaker: Young Boy  
                ~ family_photo_unlocked = true
                    ->END
        //player can now pick up photo that is on the bench
    
*[Where is your mother?]
    She said im not supposed to talk to strangers. #speaker: Young Boy
    ->END


===Cop=== 
//player meets Cop 
Can I help you? #speaker:Cop

+ [I'm looking for my sister]
    Do you want to file a missing person report? #speaker:Cop
    ++ [Yes]
        -> missing_person
    ++ [Where do I report a missing person?]
        -> missing_person
    -> DONE

+ [Where do I report a missing person?]
    -> missing_person


=== missing_person ===
How long has she been missing? #speaker:Cop

* [I'm not sure, she wasn't in her bed when I woke up.]
    So she has been missing for less than 24 hours? Then you can't file a report. #speaker:Cop
    ** [But I know she wouldn't just run away!]
        I wouldn't be so sure, people run away for different reasons. #speaker:Cop
        -> END

===OldLady===
Oh darling are you alright? You look stressed... #speaker:Old Lady 
*[I can't find my sister...]
    Maybe she will be back soon, don't worry. Did she leave you a note? #speaker:Old Lady
        **[No, nothing. Just her phone]
            Well now that you mentioned it, a young girl borrowed my phone to make a call. Said she lost hers. #speaker:Old Lady
                ***[Did she say who she was calling?]
                    She never said his name, but she said he might be her father. Not sure what she meant by that. #speaker:Old Lady
                        ****[But our dad isn't alive...]
                            Oh, you are sisters? you look nothing alike. #speaker:Old Lady
                            ~ mom_unlocked = true
                            ->END
            
*[I've been running around, I'm tierd]
    You should take a rest if you are tierd. Young people these days never know when to rest. #speaker:Old Lady
        **[I'm just looking for someone]
            Well I hope you find them, maybe they will be back later darling.#speaker:Old Lady
            ->END 


=== Doctor ===
Well hello there, you are Sasha's sister right? #speaker : Doctor
    *[Hello Dr, been a while]
        Yes it has, how are you holding up? #speaker : Doctor
            **[I've been better]
                Understandable, the news must have been a lot to procces. #speaker : Doctor
                    ***[News?]
                        Yes, from Sasha's paternity test. That you two don't share the same dad. Must have been hard to hear, since you two are so close. #speaker : Doctor
                            ****[Right ... ]
                                Anyways I when you see her, tell her I said she should come see me soon. #speaker : Doctor
                                ->END
    *[Yes, have you seen her lately?]
        You know I can't discuss patient matters with you, even if you are her sister. #speaker : Doctor
            **[Right, she wasn't in our room when I woke up]
                Well, I don't think she ran away. Maybe she left you a message somewhere. #speaker : Doctor 
                    ***[Nothing I have found]
                        Maybe you are looking in the wrong places. #speaker : Doctor
                            ->END

=== SashasFriend === 
Little Lucy! Long time no see! #speaker : Cloe

*[Hey Cloe, how have you been?]
    Oh you know, just living life. How is Sasha doing? #speaker : Cloe
        **[Wish I could tell you]
            Well I know how she has been anyways, she tells me things that not even you know. #speaker : Cloe
                ***[What do you mean?]
                    Girl, there are things you only tell your friends and not siblings. #speaker : Cloe 
                        ****[I get it you guys are close]
                            Calm it with the attitude, just face it you guys might not be as close as you think. #speaker : Cloe 
                            ->END
                        ****[Have you seen her today?]
                            Maybe, maybe not. But she did tell me to tell you "Not to look for her" Do with that as you please. #speaker : Cloe
                            ->END

*[Hey, you know no one calls me that]
    Well, to me you will always be Little Lucy, Sasha's little sister. #speaker : Cloe 
        **[Yeah, whatever. Have you seen her?]
            Since you are her little sister I will tell you. I talked to her a few days ago, but have not seen her today if that is what you are asking. #speaker : Cloe
                ***[What did you talk about?]
                    Not much, just catching up. But she said she would leave you some clues, whatever that means. #speaker : Cloe
                        ****[Clues?]
                            Well you know how much that girl loves mysteries. Maybe you should think like her and you will figure something out. #speaker : Cloe
                            ->END
                ***[So you haven't seen her today?]
                    Nope, If you are looking for her, maybe try to find some clues. That girl does love a mystery. #speaker : Cloe
                    ->END



